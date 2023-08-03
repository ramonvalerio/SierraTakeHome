import LoginBox from "../../organisms/LoginBox/LoginBox";
import { LoginAction } from "../../reducers/LoginReducer/LoginActions";
import { LoginState } from "../../reducers/LoginReducer/LoginState";
import "./loginTemplate.css";

interface LoginTemplateProps {
  state: LoginState,
  dispatch: React.Dispatch<LoginAction>
}

export default ({
  state,
  dispatch
}: LoginTemplateProps) => {
  return (
      <div className="tp-login">
        <h1>Order Management System</h1>
        <LoginBox
          state={ state }
          dispatch={ dispatch } />
      </div>
  );
}