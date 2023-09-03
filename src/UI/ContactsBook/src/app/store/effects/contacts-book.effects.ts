import { Actions, createEffect, ofType } from '@ngrx/effects';
import { tap, switchMap, map, catchError } from 'rxjs';
import { Injectable } from '@angular/core';
import { ContactsBookStore } from '../reducer.interfaces';
import { Store } from '@ngrx/store';
import {
  createContactSuccessAction,
  getContactAddressesAction,
  getContactAddressesSuccessAction,
  loadContactsAction,
  loadContactsFailAction,
  loadContactsSuccessAction,
  submitContactAction,
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
}
