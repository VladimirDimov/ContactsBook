import { createAction, props } from '@ngrx/store';
import { ContactCreateModel, ContactModel } from 'src/app/models/contact.model';

export const submitContactAction = createAction(
  '[ContactsBook] Submit Contact',
  props<{ value: ContactCreateModel }>()
);

export const loadContactsAction = createAction('[ContactsBook] Load Contacts');

export const loadContactsSuccessAction = createAction(
  '[ContactsBook] Load Contacts Success',
  props<{ value: ContactModel[] }>()
);

export const createContactSuccessAction = createAction(
  '[ContactsBook] Create Contact Success',
  props<{ value: ContactModel }>()
);

export const loadContactsFailAction = createAction(
  '[ContactsBook] Load Contacts Fail',
  props<{ value: number }>()
);
