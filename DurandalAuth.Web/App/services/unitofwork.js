/** 
	* @module UnitOfWork containing all repositories
	* @requires app
	* @requires entitymanagerprovider
	* @requires repository 
*/

define(['services/entitymanagerprovider', 'services/repository','services/privatearticlerepository', 'services/publicarticlerepository', 'durandal/app', 'services/routeconfig'],
	function (entityManagerProvider,
        repository,
        privatearticlerepository,
        publicarticlerepository,
        app,
        routeconfig) {

		var refs = {};

		/**
		* UnitOfWork ctor
		* @constructor
		*/
		var UnitOfWork = (function () {

			var unitofwork = function () {
				var provider = entityManagerProvider.create();

				/**
				* Has the current UnitOfWork changed?
				* @method
				* @return {bool}
				*/ 
				this.hasChanges = function () {
					return provider.manager().hasChanges();
				};

				/**
				* Commit changeset
				* @method
				* @return {promise}
				*/ 
				this.commit = function () {
					var saveOptions = new breeze.SaveOptions({ resourceName: routeconfig.saveChangesUrl });

					return provider.manager().saveChanges(null, saveOptions)
						.then(function (saveResult) {
							app.trigger('saved', saveResult.entities);
						});
				};

				/**
				* Rollback changes
				* @method
				*/ 
				this.rollback = function () {
					provider.manager().rejectChanges();
				};

				// Repositories
				this.privatearticles = privatearticlerepository.create(provider, "Article", routeconfig.privateArticlesUrl);
				this.publicarticles = publicarticlerepository.create(provider, "Article", routeconfig.publicArticlesUrl);
				this.categories = repository.create(provider, "Category", routeconfig.categoriesUrl, breeze.FetchStrategy.FromLocalCache);
                this.profiles = repository.create(provider, "Profile", routeconfig.profilesUrl);
				this.profile = repository.create(provider, "Profile", routeconfig.profileUrl);
				this.titles = repository.create(provider, "TitleLookup", routeconfig.titlesUrl, breeze.FetchStrategy.FromLocalCache);
				this.maritalstatuslookups = repository.create(provider, "MaritalStatusLookup", routeconfig.maritalStatusNamesUrl, breeze.FetchStrategy.FromLocalCache);
				this.entitytypelookups = repository.create(provider, "EntityTypeLookup", routeconfig.entityTypeNamesUrl, breeze.FetchStrategy.FromLocalCache);
				this.nationalitylookups = repository.create(provider, "NationalityLookup", routeconfig.nationalityNamesUrl, breeze.FetchStrategy.FromLocalCache);
				this.addresstypelookups = repository.create(provider, "AddressLookup", routeconfig.addressTypesUrl, breeze.FetchStrategy.FromLocalCache);
				this.provincelookups = repository.create(provider, "ProvinceLookup", routeconfig.provincesUrl, breeze.FetchStrategy.FromLocalCache);
				this.yesnolookups = repository.create(provider, "YesNoLookup", routeconfig.decisionLookupUrl, breeze.FetchStrategy.FromLocalCache);
				//this.citynamelookups = repository.create(provider, "CityNameLookup", routeconfig.cityNameUrl, breeze.FetchStrategy.FromLocalCache);
				this.ethnicitylookups = repository.create(provider, "EthnicityLookup", routeconfig.ethnicityNamesUrl, breeze.FetchStrategy.FromLocalCache);

			    //Lookups
			};

			return unitofwork;
		})();

		var SmartReference = (function () {

			var ctor = function () {
				var value = null;

				this.referenceCount = 0;

				this.value = function () {
					if (value === null) {
						value = new UnitOfWork();
					}

					this.referenceCount++;
					return value;
				};

				this.clear = function () {
					value = null;
					this.referenceCount = 0;

					clean();
				};
			};

			ctor.prototype.release = function () {
				this.referenceCount--;
				if (this.referenceCount === 0) {
					this.clear();
				}
			};

			return ctor;
		})();

		return {
			create: create,
			get: get
		};

		/**
		 * Get a new UnitOfWork instance
		 * @method
		 * @return {UnitOfWork}
		*/ 
		function create() {
			return new UnitOfWork();
		}

		/**
		 * Get a new UnitOfWork based on the provided key
		 * @method
		 * @param {int/string} key - Key used in the reference store
		 * @return {promise}
		*/  
		function get(key) {
			if (!refs[key]) {
				refs[key] = new SmartReference();
			}

			return refs[key];
		}

		/**
		 * Delete references
		 * @method         
		*/ 
		function clean() {
			for (key in refs) {
				if (refs[key].referenceCount == 0) {
					delete refs[key];
				}
			}
		}
	});
