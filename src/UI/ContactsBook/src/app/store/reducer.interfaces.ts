import { Action, ActionReducer } from '@ngrx/store';
import { ContactModel } from '../models/contact.model';

export interface ContactsBookStore {
  contacts: ContactModel[];
}
