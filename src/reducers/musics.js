
import { FETCHED_MUSICS } from '../actions/musics';

const initialState = {
    musics: []
};

export default (state = initialState, action) => {
    switch (action.type) {
        case FETCHED_MUSICS:
            return {
                ...state,
                musics: action.payload
            }
        default:
            return state;
    }
}