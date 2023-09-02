import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import {
  createContactSuccessAction,
  loadContactsSuccessAction,
} from './actions/contacts-book.actions';

const initialState: ContactsBookStore = {
  contacts: [],
};

export const contactsReducer = createReducer(
  initialState,
  on(loadContactsSuccessAction, (state, action) => {
    return { ...state, contacts: action.value };
  }),

  on(createContactSuccessAction, (state, action) => {
    let contacts = [...state.contacts, action.value];
    return { ...state, contacts };
  })
);
