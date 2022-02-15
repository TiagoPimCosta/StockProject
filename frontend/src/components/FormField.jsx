import React, { useState, useEffect } from 'react'

import { Form } from 'react-bootstrap';

export default function FormField({type, inputName, text, method}) {
  
  const [error, setError] = useState("");
  const [firstTime, setFirstTime] = useState(true);

  useEffect(()=>{
    if(firstTime){
      setFirstTime(false);
    }else{
      verifyInput();
    }
  },[text])

  function verifyInput(){
    if(!text.replace(/\s+/g, '')){
      setError("Please insert a " + inputName.toLowerCase());
    }else{
      setError("");
    }
  }

  const errorMessage = error ? <Form.Text className="text-error"> {error} </Form.Text> : null;

  return (
    <Form.Group className="mb-3">
      <Form.Label >{inputName}</Form.Label>
      <Form.Control
        type={type}
        id={text}
        onChange={method}
      />
      { errorMessage }
    </Form.Group>
  )
}
