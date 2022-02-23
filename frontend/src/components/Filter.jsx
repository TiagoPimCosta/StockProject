import React from "react";

import { Col, InputGroup, FormControl } from "react-bootstrap";

export default function Filter({ property, changeMethod }) {
  return (
    <Col>
      <InputGroup className="mb-3">
        <InputGroup.Text
          data-testid="labelFilter"
          id="inputGroup-sizing-default"
        >
          {property}
        </InputGroup.Text>
        <FormControl
          aria-label="Default"
          aria-describedby="inputGroup-sizing-default"
          onChange={(event) => changeMethod(event.target.value)}
        />
      </InputGroup>
    </Col>
  );
}
