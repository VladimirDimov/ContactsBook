import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import {
  createAddressSuccessAction,
  createContactSuccessAction,
  deleteAddressSuccessAction,
  deleteContactSuccessAction,
  getContactAddressesSuccessAction,
  getContactDetailsSuccessAction,
  loadContactsSuccessAction,
  updateContactSuccessAction,
} from './actions/contacts-book.actions';

import { ContactModel } from '../models/contact.model';

const initialState: ContactsBookStore = {
  contacts: [],
  contactAddresses: [],
  contactDetails: new ContactModel(),
};

export const contactsReducer = createReducer(
  initialState,
  on(loadContactsSuccessAction, (state, action) => {
    return { ...state, contacts: action.value };
  }),

  on(createContactSuccessAction, (state, action) => {
    const contacts = [...state.contacts, action.value];
    return { ...state, contacts };
  }),

  on(getContactAddressesSuccessAction, (state, action) => {
    return { ...state, contactAddresses: action.value };
  }),

  on(createAddressSuccessAction, (state, action) => {
    const contactAddresses = [...state.contactAddresses, action.value];
    let updatedContacts = JSON.parse(
      JSON.stringify(state.contacts)
    ) as ContactModel[];
    updatedContacts.map((c) => {
      if (c.id == action.value.contactId) {
        c.address = [...c.address, action.value];
      }
    });
    return {
      ...state,
      contactAddresses: contactAddresses,
      contacts: updatedContacts,
    };
  }),

  on(getContactDetailsSuccessAction, (state, action) => {
    return { ...state, contactDetails: action.value };
  }),

  on(updateContactSuccessAction, (state, action) => {
    const updatedContact = action.value;
    const contacts = state.contacts.map((c) =>
      c.id === updatedContact.id ? updatedContact : { ...c }
    );

    return { ...state, contacts: contacts };
  }),

  on(deleteAddressSuccessAction, (state, action) => {
    const addresses = [...state.contactAddresses].filter(
      (a) => a.id !== action.value
    );

    let contacts = JSON.parse(JSON.stringify(state.contacts)) as ContactModel[];
    contacts = contacts.map((contact) => {
      contact.address = contact.address.filter(
        (add) => add.id !== action.value
      );

      return contact;
    });

    return { ...state, contactAddresses: addresses, contacts: contacts };
  }),

  on(deleteContactSuccessAction, (state, action) => {
    const contacts = [...state.contacts].filter((a) => a.id !== action.value);

    return { ...state, contacts };
  })
);
