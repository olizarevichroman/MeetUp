package niceguys.apps.meetup

import android.databinding.DataBindingUtil
import android.graphics.Typeface
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.text.method.PasswordTransformationMethod
import niceguys.apps.meetup.databinding.ActivityRegisterBinding

class RegisterActivity : AppCompatActivity() {

    private lateinit var mBinding: ActivityRegisterBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        mBinding = DataBindingUtil.setContentView(this, R.layout.activity_register)

        mBinding.etRegisterPassword.typeface = Typeface.SANS_SERIF
        mBinding.etRegisterPassword.transformationMethod = PasswordTransformationMethod()

        mBinding.etRegisterConfirmPassword.typeface = Typeface.SANS_SERIF
        mBinding.etRegisterConfirmPassword.transformationMethod = PasswordTransformationMethod()
    }
}
