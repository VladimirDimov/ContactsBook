import { createAction, props } from '@ngrx/store';

export const submitContactAction = createAction(
  '[ContactsBook] Submit Contact',
  props<{ value: any }>()
);
