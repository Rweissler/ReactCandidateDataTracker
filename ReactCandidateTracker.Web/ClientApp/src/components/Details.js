import axios from'axios';
import React,{useEffect, useSate} from 'react';
import { useParams } from 'react-router-dom';
import { useTrackerContext } from '../TrackerContext';

const Details=()=>{

    const {updateConfirmedCount, updatePendingCount, updateRefusedCount}= useTrackerContext();
    const {id}= useParams();
    const[candidate, setCandidat]= useSate({
        firstName:'',
        lastName:'',
        email:'',
        phoneNumber:'',
        notes:'',
        regestrationStatus:''

    });

    useEffect(()=>{
        const getCandidate= async ()=>{   
           const {data}= await axios.get('/api/homepage/getcandidate?id=${id}');
           setCandidat(data)

        }
        getCandidate();
    },[]);

    const onRefusedClick = async () =>{
        await axios.post('/api/home/refusedcandidate', candidate);
        updateRefusedCount();
        updatePendingCount();
        candidate.regestrationStatus= 'refused';
    }

    const onConfirmedClick = async()=>{
        await axios.post('/api/home/confirmedcandidate', candidate);
        updateConfirmedCount();
        updatePendingCount();
        candidate.regestrationStatus='confirmed';
    }

    return(
        <div className='container'>
            <div className='row'>
                <div className='card card-body bg-light'>
                    <h4>First Name: {candidate.firstName}</h4>
                    <h4>Last Name: {candidate.LastName}</h4>
                    <h4>Email: {candidate.email}</h4>
                    <h4>Phone Number: {candidate.phoneNumber}</h4>
                    <h4>Notes: {candidate.notes}</h4>
                </div>
                {candidate.regestrationStatus==='Pending' &&
                <div><button className='btn btn-danger' onClick={onRefusedClick}>Refused</button>
                    <button className='btn btn-primary' onClick={onConfirmedClick}Confirmed></button></div>}
            </div>
        </div>
    )
}
export default Details;