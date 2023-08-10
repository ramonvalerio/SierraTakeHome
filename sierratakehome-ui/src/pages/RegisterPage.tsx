import { useReducer } from "react";
import RegisterTemplate from "../templates/RegisterTemplate/RegisterTemplate";
import RegisterReducer from "../reducers/RegisterReducer/RegisterReducer";
import { RegisterInitialState } from "../reducers/RegisterReducer/RegisterState";

export default () => {
  const [state, dispatch] = useReducer(RegisterReducer, RegisterInitialState);
  return (
    <RegisterTemplate
      state={ state }
      dispatch={ dispatch } />
  );
}