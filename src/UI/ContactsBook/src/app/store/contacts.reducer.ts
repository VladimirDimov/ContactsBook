import { createReducer, on } from '@ngrx/store';
import { ContactsBookStore } from './reducer.interfaces';
import { loadContactsSuccessAction } from './actions/contacts-book.actions';

const initialState: ContactsBookStore = {
  counter: 1,
  contacts: [],
};

export const contactsReducer = createReducer(
  initialState,
  on(loadContactsSuccessAction, (state, action) => {
    return { ...state, contacts: action.value };
  })
);
