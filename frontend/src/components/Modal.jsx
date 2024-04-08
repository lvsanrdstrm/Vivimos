import React, { useState, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import '../assets/styles/modal.css'

function Modal ( { children } ) {

  const { modalOpen, setModalOpen } = useContext(GlobalContext)
  const { loginOpen, setLoginOpen } = useContext(GlobalContext)
  const { regOpen, setRegOpen } = useContext(GlobalContext)

  function handleClose() {
    setModalOpen(false)
    setLoginOpen(false)
    setRegOpen(false)
  }

  return (  
    <div>
      <div className='modal'>
        <div className='modal-header' onClick={ handleClose }>&times;</div>
        <div className='modal-body'>
          {children}
        </div>
        
      </div>
      
    </div>
  )
} 


export default Modal