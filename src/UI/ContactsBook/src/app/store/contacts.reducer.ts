import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import {
  createAddressSuccessAction,
  createContactSuccessAction,
  getContactAddressesSuccessAction,
  loadContactsSuccessAction,
} from './actions/contacts-book.actions';

const initialState: ContactsBookStore = {
  contacts: [],
  contactAddresses: [],
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
  })
);
