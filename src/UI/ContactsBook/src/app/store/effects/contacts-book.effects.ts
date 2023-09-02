import { Actions, createEffect, ofType } from '@ngrx/effects';
import { tap } from 'rxjs';
import { Injectable } from '@angular/core';
import { ContactsBookStore } from '../reducer.interfaces';
import { Store } from '@ngrx/store';
import { submitContactAction } from '../actions/contacts-book.actions';
import { ApiClientService } from 'src/app/shared/api-client.service';

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
          this.apiClientService.addNewContact(action.value);
        })
      ),
    { dispatch: false }
  );
}
