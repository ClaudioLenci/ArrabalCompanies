﻿using ArrabalCompanies.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ArrabalCompanies.Data
{
    public class DB
    {
        private SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-GKOCO4VS;Initial Catalog=ArrabalCompanies;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public int CountCompanies()
        {
            return con.Query<int>("SELECT COUNT(*) FROM Companies").FirstOrDefault();
        }

        public List<string> GetCompaniesNames()
        {
            return con.Query<string>("SELECT CompanyName FROM Companies").ToList();
        }

        public string GetCompanyName(int id)
        {
            return con.Query<string>($"SELECT CompanyName FROM Companies WHERE ID = {id}").First();
        }

        public List<string> GetCompanySectors(int id)
        {
            return con.Query<string>($"SELECT (SELECT Sector FROM Sectors WHERE ID = Q.Sector_ID) FROM Sectors_Companies AS Q WHERE Company_ID = {id}").ToList();
        }

        public List<Address> GetCompanyAddresses(int id)
        {
            return con.Query<Address>($"SELECT Street, PostalCode, City, Country FROM Addresses WHERE Company_ID = {id}").ToList();
        }

        public List<Contact> GetCompanyContacts(int id)
        {
            return con.Query<Contact>($"SELECT FirstName, LastName, Telephone, Email FROM Contacts WHERE Company_ID = {id}").ToList();
        }

        public List<Comment> GetCompanyComments(int id)
        {
            return con.Query<Comment>($"SELECT Comment AS [Text], (SELECT TRIM(CONCAT(Firstname, ' ', Lastname)) FROM ArrabalStaff WHERE ID = Q.Staff_ID) AS Author, CommentDate AS [Date] FROM Comments AS Q WHERE Company_ID = {id}").ToList();
        }

        public List<string> GetSectors()
        {
            return con.Query<string>("SELECT Sector FROM Sectors").ToList();
        }

        public string GetCompanyLogo(int id)
        {
            return con.Query<string>($"SELECT Link FROM Logos WHERE Company_ID = {id}").FirstOrDefault();
        }

        public Company GetCompanyDetails(int id)
        {
            Company c = new Company();
            c.Id = id;
            c.Name = GetCompanyName(id);
            c.Sectors = GetCompanySectors(id);
            c.Addresses = GetCompanyAddresses(id);
            c.Contacts = GetCompanyContacts(id);
            c.Comments = GetCompanyComments(id);
            c.Logo = GetCompanyLogo(id);
            return c;
        }

        public List<Company> GetCompanies(int page)
        {
            var Ids = con.Query<int>($"SELECT ID FROM Companies ORDER BY CompanyName OFFSET {page * 50} ROWS FETCH NEXT 50 ROWS ONLY").ToList();
            List<Company> res = new List<Company>();
            foreach (var id in Ids)
            {
                var c = new Company();
                c.Id = id;
                c.Name = GetCompanyName(id);
                c.Sectors = GetCompanySectors(id);
                c.Addresses = GetCompanyAddresses(id);
                c.Contacts = GetCompanyContacts(id);
                res.Add(c);
            }
            return res;
        }
    }
}
