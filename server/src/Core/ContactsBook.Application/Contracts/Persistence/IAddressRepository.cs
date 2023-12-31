﻿using ContactsBook.Domain;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Application.Contracts.Persistence
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<List<Address>> GetByContactId(int contactId);
    }
}
