import React from 'react'
import Login from './Login.jsx'
import Nav from './Nav.jsx'
import logo from '../assets/images/vivimoslogo.png'
import '../assets/styles/header.css'

function Header() {
  return (
    <div className='header-container'>
      <a href="/">
        <div classname='logo-container'>
          <img className='logo' src={logo} />
        </div>
      </a>
      <Nav />
      <div className='login-header'>
        <Login />
      </div>
    </div>
  )
}

export default Header