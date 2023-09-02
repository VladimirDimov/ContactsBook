import { Actions, createEffect, ofType } from '@ngrx/effects';
import { decrement, increment } from '../actions/counter.actions';
import { tap, withLatestFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { ContactsBookStore } from '../reducer.interfaces';
import { Store } from '@ngrx/store';
import { selectCount } from '../selectors/counter.selectors';

@Injectable()
export class CounterEffects {
  constructor(
    private actions$: Actions,
    private store: Store<ContactsBookStore>
  ) {}

  saveCount = createEffect(
    () =>
      this.actions$.pipe(
        ofType(increment, decrement),
        withLatestFrom(this.store.select(selectCount)),
        tap(([action, count]) => {
          console.log(action);
          localStorage.setItem('counter', count?.toString());
        })
      ),
    { dispatch: false }
  );
}
