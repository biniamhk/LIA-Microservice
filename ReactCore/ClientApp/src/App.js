//import logo from './logo.svg';
import './App.css';


import React from 'react';
import {useState} from 'react';
import { useEffect } from "react";
import {BrowserRouter as Router, Link, Switch, Route} from 'react-router-dom';
import StartPage from './components/startpage';
import LoginPage from './components/loginpage';
import SettingsPage from './components/settingspage';
import AdminPage from './components/adminpage';
import MapPage from './components/mappage';

import FooterComponent from './components/footer';



function App() {


const [loginstate, setLogin] = useState(true);
const [users, setUsers] = useState(null);


//Get all users
async function getAllUsers() {
  //alert('fetching all users:');
  const response = await fetch('https://swapi.dev/api/planets/', {method: 'GET'});
  //setResStatus(response.status);
  const data = await response.json();
  setUsers(data.results);
  console.log(data.results);
}

  
//Post new user
async function postUser(obj) {
  let url='/test';
  alert('POST function was called!');
  /*
  const response = await fetch(url, {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
  },
  body: JSON.stringify(obj)
  });
  console.log(response);
  */
  //resetData();
}


/*
if (sessionStorage.getItem("user") === null) {
  setLogin(false);
}
else {
  setLogin(true);
}
*/

function logout() {
  sessionStorage.clear();
  setLogin(false);
  console.log(loginstate);
}



useEffect(() => {
  if (sessionStorage.getItem("user")) {
    console.log(sessionStorage.getItem("user"));
    setLogin(true);
  }
  else {
    console.log(sessionStorage.getItem("user"));
    setLogin(false);
  }
}, [loginstate]);



  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <nav>
              <Link to="/">Home</Link>
              <Link to="/map">Map</Link>
              {loginstate ? <Link to="/admin">Admin</Link> : null}
              {
              loginstate ? <Link onClick={logout} to="/">Logout</Link>
              :
              <Link to="/login">Login</Link>
              }
              {loginstate ? <Link to="/settings">Settings</Link> : null}
          </nav>
        </header>
        <main className="main-style">

        <Switch>
            <Route path="/admin" render={() => <AdminPage getAllUsers={getAllUsers} users={users} postUser={postUser}/>}></Route>
            <Route path="/map" render={() => <MapPage/>}></Route>
            <Route path="/settings" render={() => <SettingsPage/>}></Route>
            <Route path="/login" render={() => <LoginPage setLogin={setLogin}/>}></Route>
            <Route path="/"><StartPage/></Route>
        </Switch>

        </main>
        <footer className="footer-style">
            <FooterComponent/>
        </footer>

    </div>
    </Router>

    /*
    <Route path="/history" render={() => <Historik getMatches={getMatches} matches={matches} hamsters={hamsters} getAllHamsters={getAllHamsters} killMatch={killMatch}/>}></Route>
    */

    /*
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          FREDRIK PIHLGREN
        </a>
      </header>
    </div>
    */
    
  );
}

export default App;
