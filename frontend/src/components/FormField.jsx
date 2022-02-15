import React, { useState, useEffect } from 'react'

import { Form } from 'react-bootstrap';

export default function FormField({inputName, text, method}) {
  
  const [error, setError] = useState("");

  useEffect(()=>{
    verifyInput();
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
      <Form.Label htmlFor="inputPassword5">{inputName}</Form.Label>
      <Form.Control
        id={text}
        onChange={method}
      />
      { errorMessage }
    </Form.Group>
  )
}
