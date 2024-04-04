import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"

function Filter() {
  const { ads, setAds } = useContext(GlobalContext)
  const { filteredAds, setFilteredAds } = useContext(GlobalContext)
  console.log(ads)

  function filter(e) {
    let input = e.target.value
    setFilteredAds(ads.filter(item => 
      item.headline.includes(input) ||
      item.county.includes(input) ||
      item.children.includes(input) ))
  }

  return (
    <div className='filter-container'>
      <search>
        <input type="text" onChange={filter} placeholder='Sök auktion'></input>
      </search>
    </div>
  )

}

export default Filter