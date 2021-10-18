import React from 'react';
import '../mycss/Modal.css';
import '../mycss/LoginPage.css';


const CreateUserComponent = ({hide, postUser}) => {


	
	function validate(name, pass) {

	
			console.log('Time to post!');
			const userObj = {
				name,
				pass,
				id: '123'
			}
			postUser(userObj);

	}


	return(
		<div className='modal'>
			<div className='modalcontent'>
    			<nav className='close' onClick={hide}>&times;</nav>
				<main className='modalwrapper'>
					<section className='modalblock'>
						<h1>Create new user:</h1>
					</section>

					<section className="createfield">
					<label>Email:</label>
						<input type="text"

						/>
					<div className='message'></div>
					<label>Password:</label>
						<input type="password"
							
						/>
					<div className='message'></div>
					<label>Repeat password:</label>
						<input type="password"
							
						/>
					<div className='message'></div>
					<label>First name:</label>
						<input type="text"
							
						/>
					<div className='message'></div>
					<label>Last name:</label>
						<input type="text"
							
						/>
					<div className='message'></div>
					<label>Phone:</label>
						<input type="text"
							
						/>
					<div className='message'></div>
					<label>Adress:</label>
						<input type="text"
							
						/>
					<div className='message'></div>

					<button
					onClick={() => {validate('Tommy', 'myPass')}}
					>Create:</button>
					</section>

				</main>
  			</div>
		</div>
	)

}


export default CreateUserComponent;
