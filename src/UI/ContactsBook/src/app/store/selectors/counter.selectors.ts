import { ContactsBookStore } from '../reducer.interfaces';

export const selectCount = (state: ContactsBookStore) => state.counter;
