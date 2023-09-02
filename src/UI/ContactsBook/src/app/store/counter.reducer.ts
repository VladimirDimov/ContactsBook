import { createReducer, on } from '@ngrx/store';
import { decrement, increment } from './actions/counter.actions';

const initialState = 2;

export const counterReducer = createReducer(
  initialState,
  on(increment, (state, action) => {
    return state * action.value;
  }),

  on(decrement, (state, action) => {
    return state / action.value;
  })
);
