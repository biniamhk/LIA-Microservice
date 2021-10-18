import React from 'react';
import {useState} from 'react';
import { useEffect } from "react";
import Modal from './createuser';

import '../mycss/Admin.css';



const AdminComponent = ({getAllUsers, users, postUser}) => {

	const [displayModal, setDisplayModal] = useState(false);
	const [checkedState, setCheckedState] = useState([]);
	
	
	const handleOnChange = (index) => {
		//setIsChecked(!isChecked);
		//setCheckedState(!checkedState[index].check);
		let newArr = checkedState; // copying the old datas array
  		newArr[index].check=!newArr[index].check;
		alert(newArr[index].check);
		//setCheckedState(newArr);
		//alert(checkedState[index].check);
	};

	
	useEffect(() => {
		if (!users) {getAllUsers();}
		if (users) {
			//setCheckedState(new Array(users.length).fill({id:"Apa", check:false}));
		}
	}, [getAllUsers, users])


	function hideShowModal() {
		setDisplayModal(!displayModal);
	}


	if (checkedState.length <= 0 && users != null) {
		console.log('Twice?');
		//setCheckedState(); //new Array(users.length).fill({id:"Apa", check:false})
		let joined = checkedState.concat('new value');
		setCheckedState({ checkedState: joined })
		console.log(checkedState);
	}



	/*
	else {
		console.log("length: "+checkedState.length);
		console.log("id: "+checkedState[0].id+" / checked: "+checkedState[0].check);
	}
	*/


	let userCards=null;

	if (users != null) {

		userCards = users.map((user, index) => (
		<article key={user.name}
		//className={checkedState[index].check ? "ticked" : ""}
		>
			<span><h1>{user.name}</h1></span>
			<span><h1>{index}</h1></span>
			<span><h1>fggfgf</h1></span>
			<span><h1>hgh</h1></span>
			<span><button>Edit</button></span>
			<span><input type="checkbox"
				//checked={checkedState[index].check}
				//onChange={() => handleOnChange(index)}
				//onChange={handleOnChange}
			/></span>
		</article>
		));


	}


	return(
		<section>
			This is the admin page.

			<div className="buttonholder">
			<button onClick={hideShowModal}>Create new user</button>
			</div>

			<div className="usertable">
				<article>
					<span>First Name</span>
					<span>Last Name</span>
					<span>Email</span>
					<span>Phone</span>
					<span></span>
					<span></span>
				</article>
				{userCards}
			</div>
			<div>
			
			</div>

			{displayModal ? <Modal hide={hideShowModal} postUser={postUser}/> : null}
		</section>
	)

}


export default AdminComponent;
