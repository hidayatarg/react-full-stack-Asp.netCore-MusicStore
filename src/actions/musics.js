import axios from 'axios';
import { serverUrl } from '../environment/environment';



export function fetchMusics() {
    return dispatch => {
        axios.get(serverUrl + 'musics')
            .then(result => console.log(result.data))
    }
}