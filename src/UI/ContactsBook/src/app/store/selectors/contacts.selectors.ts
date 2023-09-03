import { ContactsBookStore } from '../reducer.interfaces';

export const contactsSelector = (state: any) => {
  return state.contactStore.contacts;
};

export const contactAddressesSelector = (state: any) => {
  return state.contactStore.contactAddresses;
};
