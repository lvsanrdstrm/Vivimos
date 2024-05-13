import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import '../assets/styles/login.css'
import { createPortal } from "react-dom"
import Modal from './Modal.jsx'
import { Link } from "react-router-dom"


function Login() {

  const { activeUser, setActiveUserData } = useContext(GlobalContext);
  const { modalOpen, setModalOpen } = useContext(GlobalContext)
  const { loginOpen, setLoginOpen } = useContext(GlobalContext)
  const { regOpen, setRegOpen } = useContext(GlobalContext)
  const [registrationSuccess, setRegistrationSuccess] = useState(false);


  const [formData, setFormData] = useState({
    username: '',
    password: ''
  })

  function handleButtonClick(e) {
    console.log(e)
    setModalOpen(true)
    if (e.target.value === 'login') {
      setLoginOpen(true)
    }
    else if (e.target.value === 'register') {
      setRegOpen(true)
    }
    else if (e.target.value === 'logout') {
      setActiveUserData({})
      setModalOpen(false)
    }

  }

  return (

    <div className='login-container'>
      {!activeUser.loggedIn ? (
        <>
          <button value='login' onClick={handleButtonClick}> Logga in</button>
          <button value='register' onClick={handleButtonClick}>Registera dig</button>
        </>
      ) : (
        <button value='logout' onClick={handleButtonClick}> Logga ut</button>
      )}

      {modalOpen && loginOpen && (
        createPortal(
          <Modal>&nbsp;
            <h2 className="modal-heading">Logga in</h2>
            <form onSubmit={e => fetchUser(e, formData)}>
              <label className="modal-label">
                Användarnamn:&nbsp;
              </label>
              <input type="text" name="username" className="modal-input" value={formData.username} onChange={e => handleChange(e)}></input>
              <br />
              <label className="modal-label">
                Lösenord:&nbsp;
              </label>
              <input type="password" name="password" className="modal-input" value={formData.password} onChange={e => handleChange(e)}></input>
              <br />
              <button type="submit">Login</button>
            </form>
          </Modal>, document.body
        )
      )}

      {modalOpen && regOpen && (
        <Modal>
          <h2 className="modal-heading">Registrera ny användare</h2>
          {registrationSuccess ? (
            <>
              <p>Välkommen! Du kan du lägga upp en annons och lägga bud på andras annonser.</p>
              <Link to={`/users/:id`}>
                <button className="min-sida-button" onClick={() => setModalOpen(false)}>Gå till Min Sida</button>
              </Link> </>
          ) : (
            <form onSubmit={e => createUser(e)}>
              <label className="modal-label">
                Användarnamn:
                <input type="text" name="username" className="modal-input"></input>
              </label>
              <br />
              <label className="modal-label">
                Email:
                <input type="email" name="email" className="modal-input"></input>
              </label>
              <br />
              <label className="modal-label">
                Lösenord:
                <input type="password" name="password" className="modal-input"></input>
              </label>
              <br />
              <button type="submit" className="modal-button">Registrera</button>
            </form>
          )}
        </Modal>
      )}
    </div>
  )





  function handleChange(e) {
    setFormData((prevFormData) => ({
      ...prevFormData,
      [e.target.name]: e.target.value
    }))
  }

  /*  function handleLogout() {
     setActiveUser({})
     setShowReg(false)
     setModalOpen(false)
     formData = []
   } */

  // testar ta bort, verkar vara onödig
  // function handleReg() {
  //   console.log('handle reg')
  //   setShowReg(true)
  //   setModalOpen(false)
  // }

  async function fetchUser(e, formData) {
    e.preventDefault();


    try {
      const response = await fetch('/api/auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        credentials: "same-origin",
        body: JSON.stringify(formData)
      });


      if (response.ok) {
        var userData = await response.json();
        userData = JSON.parse(userData);
        //console.log(typeof userData);
        setActiveUserData({ ...userData, loggedIn: true });
        console.log('Signed in.')

      } else {
        // Handle authentication error
      }
    } catch (error) {
      console.error('Error authenticating user:', error);
    } finally {
      setModalOpen(false);
    }
  }



  // async function createUser(e) {
  //   e.preventDefault()

  //   const regData = new FormData(e.target)
  //   const username = regData.get('username');
  //   const email = regData.get('email');
  //   const password = regData.get('password');

  //   if (!username || !email || !password) {
  //     alert('Du har missat att fylla i alla fält.')
  //     return
  //   }

  //   let regPost = Object.fromEntries(regData)
  //   regPost = {
  //     ...regPost,
  //     role: "user"
  //   }
  //   try {

  //     await fetch(`api/users/`, {
  //       method: "POST",
  //       headers: {
  //         'Content-Type': 'application/json',
  //       },
  //       body: JSON.stringify(regPost),
  //     })
  //       .then((response) => response.json())
  //       .then((data) => console.log('New user added:', data))
  //       .catch((error) => console.error('Error adding new user:', error))

  //   } catch (error) {
  //     console.error('Error fetching mock data:', error)
  //   } finally {
  //     setModalOpen(false)
  //   }

  // }

  async function createUser(e) {
    e.preventDefault();

    const regData = new FormData(e.target);
    const username = regData.get('username');
    const email = regData.get('email');
    const password = regData.get('password');

    if (!username || !email || !password) {
      alert('Du har missat att fylla i alla fält.');
      return;
    }

    const userData = {
      username: username,
      email: email,
      password: password
    };

    try {
      const response = await fetch('/api/auth/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(userData)
      });

      if (response.ok) {
        const data = await response.json();
        console.log('New user added:', data);
        setActiveUserData({ ...userData, loggedIn: true });
        setRegistrationSuccess(true);
      } else {
        console.error('Error adding new user:', response.statusText);
      }
    } catch (error) {
      console.error('Error adding new user:', error);
    } finally {
      //setModalOpen(false);
    }
  }


}



export default Login