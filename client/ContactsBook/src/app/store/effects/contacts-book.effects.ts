import { Actions, createEffect, ofType } from '@ngrx/effects';
import { tap, switchMap, map, catchError } from 'rxjs';
import { Injectable } from '@angular/core';
import { ContactsBookStore } from '../reducer.interfaces';
import { Store } from '@ngrx/store';
import {
  createAddressAction,
  createAddressSuccessAction,
  createContactSuccessAction,
  deleteAddressAction,
  deleteAddressSuccessAction,
  deleteContactAction,
  deleteContactSuccessAction,
  errorMessageAction,
  getContactAddressesAction,
  getContactAddressesSuccessAction,
  getContactDetailsAction,
  getContactDetailsSuccessAction,
  loadContactsAction,
  loadContactsFailAction,
  loadContactsSuccessAction,
  submitContactAction,
  successMessageAction,
  updateContactAction,
  updateContactSuccessAction,
} from '../actions/contacts-book.actions';
import { ApiClientService } from 'src/app/shared/api-client.service';
import { of } from 'rxjs/internal/observable/of';
import { MessageService } from 'primeng/api';
import { ClearFormService } from 'src/app/shared/clear-form.service';

@Injectable()
export class ContatsBookEffects {
  constructor(
    private actions$: Actions,
    private store: Store<ContactsBookStore>,
    private apiClientService: ApiClientService,
    private messageService: MessageService,
    private clearFormService: ClearFormService
  ) {}

  createContactEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(submitContactAction),
        switchMap((action) => {
          console.log('from effects: ', action);
          return this.apiClientService.addNewContact(action.value).pipe(
            map((response) => {
              const createdContact = {
                ...action.value,
                id: response,
                address: [],
              };
              this.store.dispatch(
                createContactSuccessAction({ value: createdContact })
              );
              this.store.dispatch(
                successMessageAction({ value: 'Contact created' })
              );
              this.clearFormService.clearForm();
            }),
            catchError((err: any) => {
              return of(
                this.store.dispatch(
                  errorMessageAction({
                    value: err || 'Unable to create contact',
                  })
                )
              );
            })
          );
        })
      ),
    { dispatch: false }
  );

  getContactsEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(loadContactsAction),
        switchMap((action) => {
          return this.apiClientService.getAllContacts().pipe(
            map((products) => {
              return loadContactsSuccessAction({ value: products });
            }),
            catchError((err) =>
              of(
                errorMessageAction({
                  value: 'Unable to fetch contacts from the server.',
                })
              )
            )
          );
        })
      ),
    { dispatch: true }
  );

  getContactAddressesEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(getContactAddressesAction),
        switchMap((action) => {
          return this.apiClientService
            .getContactAddresses(action.contactId)
            .pipe(
              map((addresses) => {
                return getContactAddressesSuccessAction({ value: addresses });
              }),
              catchError((err) =>
                of(
                  errorMessageAction({
                    value: 'Unable to fetch addresses from the server.',
                  })
                )
              )
            );
        })
      ),
    { dispatch: true }
  );

  createAddressEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createAddressAction),
        switchMap((action) => {
          return this.apiClientService.addNewAddress(action.value).pipe(
            map((response) => {
              const createdAddress = { ...action.value, id: response };
              this.store.dispatch(
                createAddressSuccessAction({ value: createdAddress })
              );

              this.store.dispatch(
                successMessageAction({ value: 'Address created' })
              );
            }),
            catchError((err) =>
              of(
                this.store.dispatch(
                  errorMessageAction({ value: 'Unable to create address' })
                )
              )
            )
          );
        })
      ),
    { dispatch: false }
  );

  getContactDetailsEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(getContactDetailsAction),
        switchMap((action) => {
          return this.apiClientService.getContactDetails(action.value).pipe(
            map((contactDetails) => {
              return getContactDetailsSuccessAction({ value: contactDetails });
            }),
            catchError((err) =>
              of(
                errorMessageAction({
                  value: 'Unable to fetch contact details from the server.',
                })
              )
            )
          );
        })
      ),
    { dispatch: true }
  );

  updateContactEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateContactAction),
        switchMap((action) => {
          return this.apiClientService.updateContact(action.value).pipe(
            map((_) => {
              this.store.dispatch(
                updateContactSuccessAction({ value: action.value })
              );
              this.store.dispatch(
                successMessageAction({ value: 'Contact updated' })
              );
            }),
            catchError((err) =>
              of(
                this.store.dispatch(
                  errorMessageAction({
                    value: err || 'Unable to update contact',
                  })
                )
              )
            )
          );
        })
      ),
    { dispatch: false }
  );

  deleteAddressEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteAddressAction),
        switchMap((action) => {
          console.log('from effects: ', action);
          return this.apiClientService.deleteAddress(action.value).pipe(
            map((_) => {
              this.store.dispatch(
                deleteAddressSuccessAction({ value: action.value })
              );
              this.store.dispatch(
                successMessageAction({ value: 'Address deleted' })
              );
            }),
            catchError((err) =>
              of(
                this.store.dispatch(
                  errorMessageAction({ value: 'Unable to delete address' })
                )
              )
            )
          );
        })
      ),
    { dispatch: false }
  );

  deleteContactEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteContactAction),
        switchMap((action) => {
          console.log('from effects: ', action);
          return this.apiClientService.deleteContact(action.value).pipe(
            map((_) => {
              this.store.dispatch(
                deleteContactSuccessAction({ value: action.value })
              );
              this.store.dispatch(
                successMessageAction({ value: 'Contact deleted' })
              );
            }),
            catchError((err) =>
              of(
                this.store.dispatch(
                  errorMessageAction({ value: 'Unable to delete contact' })
                )
              )
            )
          );
        })
      ),
    { dispatch: false }
  );

  successMessageEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(successMessageAction),
        tap((action) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: action.value,
            closable: false,
          });
        })
      ),
    { dispatch: false }
  );

  errorMessageEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(errorMessageAction),
        tap((action: any) => {
          if (!action) {
            this.messageService.add({
              severity: 'error',
              summary: 'Error',
              detail: 'Operation failed',
              closable: false,
            });
          }

          const errors = action?.value?.error?.errors;
          const value = action?.value;

          const errorMessages =
            typeof value === 'string'
              ? value
              : errors
              ? Object.values(errors)
                  .map((err: any) => err.toString())
                  .join('\n')
              : 'Operation failed';

          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: errorMessages,
            closable: false,
          });
        })
      ),
    { dispatch: false }
  );
}
