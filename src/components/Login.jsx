import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import '../assets/styles/login.css'
import { createPortal } from "react-dom"
import Modal from './Modal.jsx'


function Login() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)
  const { modalOpen, setModalOpen } = useContext(GlobalContext)
  const { loginOpen, setLoginOpen } = useContext(GlobalContext)
  const { regOpen, setRegOpen } = useContext(GlobalContext)


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
      setActiveUser({})
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
            <button className="modal-button" onClick={handleReg}>Registrera</button>
          </form>
        </Modal>
      )}
    </div>
  )




  useEffect(() => {
    console.log(activeUser)
  }, [activeUser])

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

  function handleReg() {
    console.log('handle reg')
    setShowReg(true)
    setModalOpen(false)
  }

  async function fetchUser(e, formData) {
    e.preventDefault()
    console.log(formData.username)
    try {
      const response = await fetch(`/api/users/?username=${formData.username}&password=${formData.password}`)
      const data = await response.json()

      if (data[0]) {
        console.log(data, formData)
        setActiveUser({
          ...data[0],
          loggedIn: true
        })
      }
    } catch (error) {
      console.error('Error fetching mock data:', error)
    } finally {
      setModalOpen(false)
    }
  }


  async function createUser(e) {
    e.preventDefault()

    const regData = new FormData(e.target)
    const username = regData.get('username');
    const email = regData.get('email');
    const password = regData.get('password');

    if (!username || !email || !password) {
      alert('Du har missat att fylla i alla fält.')
      return
    }

    let regPost = Object.fromEntries(regData)
    regPost = {
      ...regPost,
      role: "user"
    }
    try {
      await fetch(`api/users/`, {
        method: "POST",
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(regPost),
      })
        .then((response) => response.json())
        .then((data) => console.log('New user added:', data))
        .catch((error) => console.error('Error adding new user:', error))

    } catch (error) {
      console.error('Error fetching mock data:', error)
    } finally {
      setModalOpen(false)
    }

  }

}



export default Login