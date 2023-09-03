import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import {
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
    let contacts = [...state.contacts];
    return { ...state, contactAddresses: action.value };
  })
);
