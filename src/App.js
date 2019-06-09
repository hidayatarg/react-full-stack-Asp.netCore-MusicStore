import React, { Component } from 'react';
import './App.css';
import MusicsPage from './components/pages/MusicsPage';
import { Route } from 'react-router-dom';

import 'semantic-ui-css/semantic.min.css';
import { Container } from 'semantic-ui-react';

import Footer from './components/Footer';
import Header from './components/Header';

class App extends Component {
  
  render() {
    return (
      <div className="App">
       <Header/>

        <Container text>

          <Route path='/musics' component={MusicsPage}></Route>
          
        </Container>

        <Footer/>


      </div>
    );
  }

}

export default App;
