import React from 'react';

import { useState } from 'react';
import '../mycss/LoginPage.css';
import { useHistory } from "react-router-dom";

//const sanitize = require('../modules/sanitize.js');


//const LoginPage = ({some inputdata here}) => {
const LoginPage = ({setLogin}) => {

	let history = useHistory();

	const [myName, setName] = useState('');
	const [errorName, setErrorName] = useState('');

	const [myPass, setPass] = useState('');
	const [errorPass, setErrorPass] = useState('');

	function getUser(name,pass) {
		console.log(`Get user with username: ${name} and password: ${pass}`);

		// let url="https://swapi.dev/api/planets/1/";
		let url = "https://localhost:5021/api/weather";
		//test

		/*
		fetch(url)
        .then(response => response.json())
        .then(data => {
        //arr.push(data);
        //writeList(arr[page]); //data
        //console.log("arr page 0 = "+arr[page][0]);
        //console.log("arr page 0 results length = "+arr[page][0].results.length);
        console.log(data);
		});
		*/

		sessionStorage.setItem("user", "123");
		setLogin(true);
		history.push("/");
  		
	}

	
	function sanitize(string) {
		//removes any non-allowed characters from input string and returns the result:
		const map = {
			'&': '',
			'<': '',
			'>': '',
			'"': '',
			"'": '',
			"/": '',
		};
		const reg = /[&<>"'/]/ig;
		if (string.length > 0) {return string.replace(reg, (match)=>(map[match]));}
		return string;
	}
	


	function validate(name, pass) {

		setErrorName('');
		setErrorPass('');

		//add sanitizer:
		name=sanitize(name);
		pass=sanitize(pass);

		let post=true;
		if (name.length <= 0) {setErrorName('Please type username');post=false;}
		if (typeof(name) !== "string") {setErrorName('Username must be a string');post=false;}

		if (pass.length <= 0) {setErrorPass('Please type password');post=false;}
		if (typeof(pass) !== "string") {setErrorPass('Password must be a string');post=false;}

		if (post) {
			getUser(name, pass);
		}

	}

	return(
		<div className="pagestyle">
			<section className="loginfield">
			<h1>Login:</h1>
			<label>Username:</label>
				<input type="text"
					onChange={event => setName(event.target.value)}
					className={(errorName.length <= 0) ? '' : 'errorfield'}
					value={myName}
				/>
				<div className='message'>{errorName}</div>
			<label>Password:</label>
				<input type="password"
					onChange={event => setPass(event.target.value)}
					className={(errorPass.length <= 0) ? '' : 'errorfield'}
					value={myPass}
				/>
				<div className='message'>{errorPass}</div>

			<button
			onClick={() => {validate(myName, myPass)}}
			>Login:</button>
			</section>
		</div>
	)

}


export default LoginPage;
