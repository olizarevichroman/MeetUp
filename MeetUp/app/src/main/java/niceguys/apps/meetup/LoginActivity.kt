package niceguys.apps.meetup

import android.databinding.DataBindingUtil
import android.graphics.Typeface
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.text.method.PasswordTransformationMethod
import niceguys.apps.meetup.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {

    private lateinit var mBinding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        mBinding = DataBindingUtil.setContentView(this, R.layout.activity_login)

        mBinding.etLoginPassword.typeface = Typeface.SANS_SERIF
        mBinding.etLoginPassword.transformationMethod = PasswordTransformationMethod()
    }
}
