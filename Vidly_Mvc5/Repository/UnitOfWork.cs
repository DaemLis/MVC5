﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Vidly_Mvc5.Models;
using Vidly_Mvc5.Repository;

namespace Vidly_Mvc5.Repository
{
    public interface IUnitOfWork
    {
        MovieRepository Movies { get;}
        CustomerRepository Customers { get;}

        IEnumerable<MembershipType> MembershipTypes { get; }
        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // private MyContext db = new MyContext(); // EF6 connection to Db
        private MovieRepository movieRepository;
        private CustomerRepository customerRepository;
        private IEnumerable<MembershipType> membershipType;

        private readonly ApplicationDbContext _context;


        public  MovieRepository Movies
        {//dependency Property injection Movies
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository();
                return movieRepository;
            }
        }
        public CustomerRepository Customers
        {//dependency Property injection Customers
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository();
                return customerRepository;
            }
        }

        public IEnumerable<MembershipType> MembershipTypes
        {
            get
            {
                if (membershipType == null)
                    using (var membershipTypeContext = new ApplicationDbContext())
                        membershipType = membershipTypeContext.MembershipTypes.ToList(); 
               return membershipType;
                
            }
        }

        /************************************/
        public void SaveChanges()
        {
            _context.SaveChanges(); // Saving changes in Db
        }

        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}