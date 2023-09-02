import { ContactsBookStore } from '../reducer.interfaces';

export const contactsSelector = (state: any) => {
  return state.contactStore.contacts;
};
