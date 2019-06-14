import axios from 'axios';
import { serverUrl } from '../environment/environment';

export const FETCHED_MUSICS = "FETCHED_MUSICS";
export const FETCHED_MUSICS_ERROR = "FETCHED_MUSICS_ERROR";

export function fetchMusics() {
    return dispatch => {
        axios.get(serverUrl + 'musicssg')
            .then(result => result.data )
            // use it in the reducer
            .then(data => dispatch({
                type: FETCHED_MUSICS,
                payload: data
            }))
            .catch(error => dispatch({
                type: FETCHED_MUSICS_ERROR,
                payload: error
            }))
    }
}