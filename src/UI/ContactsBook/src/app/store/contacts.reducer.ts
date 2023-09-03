import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import {
  createAddressSuccessAction,
  createContactSuccessAction,
  getContactAddressesSuccessAction,
  getContactDetailsSuccessAction,
  loadContactsSuccessAction,
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
    let contacts = [...state.contacts, action.value];
    return { ...state, contacts };
  }),

  on(getContactAddressesSuccessAction, (state, action) => {
    return { ...state, contactAddresses: action.value };
  }),

  on(createAddressSuccessAction, (state, action) => {
    let contactAddresses = [...state.contactAddresses, action.value];
    return { ...state, contactAddresses: contactAddresses };
  }),

  on(getContactDetailsSuccessAction, (state, action) => {
    return { ...state, contactDetails: action.value };
  })
);
