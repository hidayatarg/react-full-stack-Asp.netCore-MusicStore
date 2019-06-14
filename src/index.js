import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';

// creating Redux store
import { createStore, applyMiddleware } from 'redux';
import rootReducer from './reducers/rootReducer';

// thunk middleware
import thunk from 'redux-thunk';

import { composeWithDevTools } from 'redux-devtools-extension';
import { Provider } from 'react-redux';
// router
import { BrowserRouter } from 'react-router-dom';

// logger 
import logger from 'redux-logger';



const store = createStore(
    rootReducer,
    // applymiddleware(thunk)
    composeWithDevTools(
        applyMiddleware(thunk, logger)
    )
);

ReactDOM.render(
    <BrowserRouter>
        <Provider store={store}>
            <App />
        </Provider>
    </BrowserRouter>,
    document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
