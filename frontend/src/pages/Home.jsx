import { useContext } from "react"
import { GlobalContext } from "../GlobalContext"
import AdList from "../components/AdList"
import Filter from '../components/Filter'


function Home() {

  //const { ads, setAds } = useContext(GlobalContext)
  //console.log(ads)

  return (
    <>
    <Filter />
    <AdList />
    </>
  );
}

export default Home