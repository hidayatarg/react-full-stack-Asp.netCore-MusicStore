import axios from 'axios';
import { serverUrl } from '../environment/environment';

export const FETCHED_MUSICS = "FETCHED_MUSICS";

export function fetchMusics() {
    return dispatch => {
        axios.get(serverUrl + 'musics')
            .then(result => result.data )
            // use it in the reducer
            .then(data => dispatch({
                type: FETCHED_MUSICS,
                payload: data
            }))
            .then(error => console.log(error))
    }
}