import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"

function Filter() {
  const { ads, setAds } = useContext(GlobalContext)
  const { filteredAds, setFilteredAds } = useContext(GlobalContext)
  console.log(ads)

  function filter(e) {
    let input = e.target.value
    setFilteredAds(ads.filter(item =>
      item.Headline.toLowerCase().includes(input) ||
      item.Presentation.toLowerCase().includes(input) ||
      item.County.toLowerCase().includes(input) ||
      item.Gender.toLowerCase().includes(input)))
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