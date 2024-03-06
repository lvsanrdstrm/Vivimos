import React from 'react'
import Header from './Header.jsx'
import Footer from './Footer.jsx'
import '../assets/styles/layout.css'

function Layout({children}) {
  return (
    <>
      <Header />
      <div className='page-container'>
        {children}
      </div>
      <Footer />
    </>
  )
}

export default Layout