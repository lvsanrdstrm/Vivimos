import React from 'react'
import Header from './Header.jsx'
import Footer from './Footer.jsx'
import AdList from "./AdList.jsx";
import '../assets/styles/layout.css'

function Layout({ children }) {
  return (
    <>
      <div className='page'>
        <Header />
        <div className='page-container'>

          {children}

        </div>
        <Footer />
      </div>
    </>
  )
}

export default Layout