import React from 'react';
import logo from './logo.svg';
import './App.css';
import MusicsPage from './components/pages/MusicsPage';
import { Link, Route } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <p>
          <Link to="musics">Musics</Link>
        </p>
        <Route path ="/musics" component={MusicsPage}></Route>
      </header>
    </div>
  );
}

export default App;
