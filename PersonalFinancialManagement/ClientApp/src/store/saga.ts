import { put, takeEvery, all, call, delay } from 'redux-saga/effects';

function* incrementAync() {
    
}

function* watchIncrementAsync() {
}

export function* rootSagas() {
    yield all([watchIncrementAsync()]);
}