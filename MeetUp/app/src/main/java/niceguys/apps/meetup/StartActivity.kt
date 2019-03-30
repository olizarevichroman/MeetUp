package niceguys.apps.meetup

import android.content.Intent
import android.databinding.DataBindingUtil
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import niceguys.apps.meetup.databinding.ActivityStartBinding
import org.jetbrains.anko.sdk27.coroutines.onClick

class StartActivity : AppCompatActivity() {

    private lateinit var mBinding: ActivityStartBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        mBinding = DataBindingUtil.setContentView(this, R.layout.activity_start)

        mBinding.btnSignIn.onClick {
            startActivity(Intent(baseContext, LoginActivity::class.java))
        }
        mBinding.btnRegister.onClick {
            startActivity(Intent(baseContext, RegisterActivity::class.java))
        }
    }
}
