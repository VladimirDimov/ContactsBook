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
  getContactAddressesAction,
  getContactAddressesSuccessAction,
  getContactDetailsAction,
  getContactDetailsSuccessAction,
  loadContactsAction,
  loadContactsFailAction,
  loadContactsSuccessAction,
  submitContactAction,
  updateContactAction,
  updateContactSuccessAction,
} from '../actions/contacts-book.actions';
import { ApiClientService } from 'src/app/shared/api-client.service';
import { of } from 'rxjs/internal/observable/of';

@Injectable()
export class ContatsBookEffects {
  constructor(
    private actions$: Actions,
    private store: Store<ContactsBookStore>,
    private apiClientService: ApiClientService
  ) {}

  submitNewContactForm = createEffect(
    () =>
      this.actions$.pipe(
        ofType(submitContactAction),
        tap((action) => {
          console.log('from effects: ', action);
          this.apiClientService
            .addNewContact(action.value)
            .pipe(
              map((response) => {
                const createdContact = { ...action.value, id: response };
                this.store.dispatch(
                  createContactSuccessAction({ value: createdContact })
                );
              }),
              catchError((err) => of(loadContactsFailAction(err)))
            )
            .subscribe();
        })
      ),
    { dispatch: false }
  );

  loadContactsEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(loadContactsAction),
        switchMap((action) => {
          return this.apiClientService.getAllContacts().pipe(
            map((products) => {
              return loadContactsSuccessAction({ value: products });
            }),
            catchError((err) => of(loadContactsFailAction(err)))
          );
        })
      ),
    { dispatch: true }
  );

  getContactAddresses = createEffect(
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
              catchError((err) => of(loadContactsFailAction(err)))
            );
        })
      ),
    { dispatch: true }
  );

  submitNewAddressForm = createEffect(
    () =>
      this.actions$.pipe(
        ofType(createAddressAction),
        tap((action) => {
          console.log('from effects: ', action);
          this.apiClientService
            .addNewAddress(action.value)
            .pipe(
              map((response) => {
                const createdAddress = { ...action.value, id: response };
                this.store.dispatch(
                  createAddressSuccessAction({ value: createdAddress })
                );
              }),
              catchError((err) => of(loadContactsFailAction(err)))
            )
            .subscribe();
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
            catchError((err) => of(loadContactsFailAction(err)))
          );
        })
      ),
    { dispatch: true }
  );

  updateContactEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(updateContactAction),
        tap((action) => {
          console.log('from effects: ', action);
          this.apiClientService
            .updateContact(action.value)
            .pipe(
              map((_) => {
                this.store.dispatch(
                  updateContactSuccessAction({ value: action.value })
                );
              }),
              catchError((err) => of(loadContactsFailAction(err)))
            )
            .subscribe();
        })
      ),
    { dispatch: false }
  );

  deleteAddressEffect = createEffect(
    () =>
      this.actions$.pipe(
        ofType(deleteAddressAction),
        tap((action) => {
          console.log('from effects: ', action);
          this.apiClientService
            .deleteAddress(action.value)
            .pipe(
              map((_) => {
                this.store.dispatch(
                  deleteAddressSuccessAction({ value: action.value })
                );
              }),
              catchError((err) => of(loadContactsFailAction(err)))
            )
            .subscribe();
        })
      ),
    { dispatch: false }
  );
}
