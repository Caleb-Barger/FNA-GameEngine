using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

class FNAGame : Game
{
	static void Main(string[] args)
	{
		using (FNAGame g = new FNAGame())
		{
			g.Run();
		}
	}

	// Inputs
	private KeyboardState keyboardPrev = new KeyboardState();
	private MouseState mousePrev = new MouseState();

	// 2D sprite
	private SpriteBatch batch;
	private Texture2D texture;

	private FNAGame()
	{
		GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

		// Typically you would load a config here...
		gdm.PreferredBackBufferWidth = 1280;
		gdm.PreferredBackBufferHeight = 720;
		gdm.IsFullScreen = false;
		gdm.SynchronizeWithVerticalRetrace = true;

		// All assests are loaded here
		Content.RootDirectory = "Content";
	}

	protected override void Initialize()
	{
		/* This is a nice place to start up the engine, after
		 * loading configuration stuff in the constructor
		 */
		base.Initialize();
	}

	protected override void LoadContent()
	{
		// Load textures, sounds, and so on in here...

		// create the new batch
		batch = new SpriteBatch(GraphicsDevice);

		// load this texture from Content/FNATexture.png
		texture = Content.Load<Texture2D>("shovel.png");

		//base.LoadContent();
	}

	protected override void UnloadContent()
	{
		batch.Dispose();
		texture.Dispose();
	}

	protected override void Update(GameTime gameTime)
	{
		// Run game logic in here. Do NOT render anything here!

		KeyboardState keyboardCur = Keyboard.GetState();
		MouseState mouseCur = Mouse.GetState();

		if (keyboardCur.IsKeyDown(Keys.Space) && keyboardPrev.IsKeyUp(Keys.Space))
        {
			System.Console.WriteLine("Space Bar was pressed!");
        }

		if (mouseCur.RightButton == ButtonState.Released && mouseCur.RightButton == ButtonState.Pressed)
        {
			System.Console.WriteLine("Right mouse was released!");
        }

		keyboardPrev = keyboardCur;
		mousePrev = mouseCur;

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		// Render stuff in here. Do NOT run game logic in here!
		GraphicsDevice.Clear(Color.CornflowerBlue);

		batch.Begin();
		batch.Draw(texture, new Vector2(100, 100), Color.White);
		batch.End();

		base.Draw(gameTime);
	}
}