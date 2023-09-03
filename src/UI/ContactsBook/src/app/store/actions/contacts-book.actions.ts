import { createAction, props } from '@ngrx/store';
import {
  AddressModel,
  ContactCreateModel,
  ContactModel,
} from 'src/app/models/contact.model';

export const submitContactAction = createAction(
  '[ContactsBook] Submit Contact',
  props<{ value: ContactCreateModel }>()
);

export const loadContactsAction = createAction('[ContactsBook] Load Contacts');

export const loadContactsSuccessAction = createAction(
  '[ContactsBook] Load Contacts Success',
  props<{ value: ContactModel[] }>()
);

export const getContactDetailsAction = createAction(
  '[ContactsBook] Get Contact Details',
  props<{ value: number }>()
);

export const getContactDetailsSuccessAction = createAction(
  '[ContactsBook] Get Contact Details Success',
  props<{ value: ContactModel }>()
);

export const createContactSuccessAction = createAction(
  '[ContactsBook] Create Contact Success',
  props<{ value: ContactModel }>()
);

export const loadContactsFailAction = createAction(
  '[ContactsBook] Load Contacts Fail',
  props<{ value: number }>()
);

export const getContactAddressesAction = createAction(
  '[ContactsBook] Get contact addresses',
  props<{ contactId: number }>()
);

export const getContactAddressesSuccessAction = createAction(
  '[ContactsBook] Get contact addresses success',
  props<{ value: AddressModel[] }>()
);

export const createAddressAction = createAction(
  '[ContactsBook] Create Address',
  props<{ value: AddressModel }>()
);

export const createAddressSuccessAction = createAction(
  '[ContactsBook] Create Address Success',
  props<{ value: AddressModel }>()
);

export const updateContactAction = createAction(
  '[ContactsBook] Update Contact',
  props<{ value: ContactModel }>()
);

export const updateContactSuccessAction = createAction(
  '[ContactsBook] Update Contact Success',
  props<{ value: ContactModel }>()
);

export const deleteAddressAction = createAction(
  '[ContactsBook] Delete Address',
  props<{ value: number }>()
);

export const deleteAddressSuccessAction = createAction(
  '[ContactsBook] Delete Address Success',
  props<{ value: number }>()
);

export const deleteContactAction = createAction(
  '[ContactsBook] Delete Contact',
  props<{ value: number }>()
);

export const deleteContactSuccessAction = createAction(
  '[ContactsBook] Delete Contact Success',
  props<{ value: number }>()
);

export const successMessageAction = createAction(
  '[Common] Success Message',
  props<{ value: string }>()
);

export const errorMessageAction = createAction(
  '[Common] Error Message',
  props<{ value: string }>()
);
