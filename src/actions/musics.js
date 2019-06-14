import axios from 'axios';
import { serverUrl } from '../environment/environment';



export function fetchMusics() {
    return dispatch => {
        axios.get(serverUrl + 'musics')
            .then(result => result.data )
            .then(data => console.log(data))
            .then(error => console.log(error))
    }
}