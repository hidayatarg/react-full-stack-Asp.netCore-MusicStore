
import { FETCHED_MUSICS,
         FETCHED_MUSICS_ERROR } from '../actions/musics';

const initialState = {
    fetching: false,
    fetched: false,
    musics: [],
    error: {}
};

export default (state = initialState, action) => {
    switch (action.type) {
        case FETCHED_MUSICS:
            return {
                ...state,
                musics: action.payload
            }
        case FETCHED_MUSICS_ERROR:
            return {
                ...state,
                error: action.payload
            }
        default:
            return state;
    }
}